package com.orderservice.services

import com.orderservice.dtos.orders.OrderCreateDto
import com.orderservice.models.Order
import com.orderservice.models.OrderLine
import com.orderservice.repositories.OrderRepository
import io.netty.handler.codec.AsciiHeadersEncoder.NewlineType
import org.springframework.stereotype.Service

@Service
class OrderService(private val orderRepo: OrderRepository) {
    
    fun placeOrder(orderCreateDto: OrderCreateDto):Order {
        val order = Order(
            userId = orderCreateDto.userId,
            total = orderCreateDto.total,
            shippingAddress = orderCreateDto.shippingAddress,
        )

        val orderLines = orderCreateDto.orderLines.map { orderLineDto ->
            OrderLine.fromCreateDto(orderLineDto, order)
        }.toList()
        
        order.orderLines = orderLines

        return orderRepo.save(order)
    }
}