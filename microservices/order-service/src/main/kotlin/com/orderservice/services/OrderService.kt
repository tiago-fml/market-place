package com.orderservice.services

import com.orderservice.dtos.orders.OrderCreateDto
import com.orderservice.models.Order
import com.orderservice.models.OrderLine
import com.orderservice.repositories.OrderRepository
import org.springframework.stereotype.Service

@Service
class OrderService(private val orderRepo: OrderRepository) {
    
    fun placeOrder(orderCreateDto: OrderCreateDto):Order {
        val orderLines = orderCreateDto.orderLines.map { orderLineDto ->
            OrderLine.fromCreateDto(orderLineDto)
        }.toList()
        
        val order = Order(
            userId = orderCreateDto.userId,
            total = orderCreateDto.total,
            shippingAddress = orderCreateDto.shippingAddress,
            orderLines = orderLines
        )

        orderLines.forEach { it.order = order }
        
        return orderRepo.save(order)
    }
}