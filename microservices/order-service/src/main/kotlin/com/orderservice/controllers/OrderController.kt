package com.orderservice.controllers

import com.orderservice.dtos.orders.OrderCreateDto
import com.orderservice.models.Order
import com.orderservice.services.OrderService
import org.springframework.data.domain.jaxb.SpringDataJaxb.OrderDto
import org.springframework.http.HttpStatus
import org.springframework.http.ResponseEntity
import org.springframework.web.bind.annotation.*
import java.util.UUID

@RestController
@RequestMapping("/api/orders")
class OrderController(private val orderService: OrderService) {
    
    @PostMapping
    fun placeOrder(@RequestBody orderCreateDto: OrderCreateDto): ResponseEntity<com.orderservice.dtos.orders.OrderDto> {
        try {
            val order = orderService.placeOrder(orderCreateDto)
            return ResponseEntity(order.toDto(), HttpStatus.CREATED)
        } catch (e: Exception) {
            // Handle the exception and return a meaningful error response
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(null)
        }
    }

    @GetMapping
    fun getOrderById(orderId: UUID): ResponseEntity<Int> {
        try {
            return ResponseEntity(1,HttpStatus.CREATED)
        } catch (e: Exception) {
            // Handle the exception and return a meaningful error response
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(null)
        }
    }
}